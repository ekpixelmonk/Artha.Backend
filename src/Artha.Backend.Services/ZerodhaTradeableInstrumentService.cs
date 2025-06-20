using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Artha.Backend.Services.Interface;
using Artha.Backend.Shared.Dto;
using Microsoft.Extensions.Logging;
using CsvHelper;
using Artha.Backend.Services.Mapper;
using Artha.Backend.Domain.Contract.Interface;
using Artha.Backend.Domain.Entity;

namespace Artha.Backend.Services
{
    /// <summary>
    /// Service implementation for ZerodhaTradeableInstrument operations.
    /// </summary>
    public class ZerodhaTradeableInstrumentService : IZerodhaTradeableInstrumentService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IZerodhaConfigService _zerodhaConfigService;
        private readonly ILogger<ZerodhaTradeableInstrumentService> _logger;
        private readonly IZerodhaTradeableInstrumentRepository _repository;

        public ZerodhaTradeableInstrumentService(
            IHttpClientFactory httpClientFactory,
            IZerodhaConfigService zerodhaConfigService,
            ILogger<ZerodhaTradeableInstrumentService> logger,
            IZerodhaTradeableInstrumentRepository repository)
        {
            _httpClientFactory = httpClientFactory;
            _zerodhaConfigService = zerodhaConfigService;
            _logger = logger;
            _repository = repository;
        }

        public async Task<string> InsertZerodhaTradeableInstrumentsAsync()
        {
            try
            {
                // Fetch API key and access token from ZerodhaConfigService
                var config = await _zerodhaConfigService.GetZerodhaConfigAsync();
                if (config == null)
                    throw new Exception("Zerodha config not found");

                var apiKey = config.APIKey;
                var accessToken = config.AccessToken;

                var client = _httpClientFactory.CreateClient();
                var request = new HttpRequestMessage(HttpMethod.Get, "https://api.kite.trade/instruments/NSE");
                request.Headers.Add("X-Kite-Version", "3");
                request.Headers.Authorization = new AuthenticationHeaderValue("token", $"{apiKey}:{accessToken}");

                _logger.LogInformation("Starting fetch of Zerodha tradeable instruments from external API.");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var csvContent = await response.Content.ReadAsStringAsync();

                // Parse CSV to List<ZerodhaTradeableInstrumentDto> using CsvHelper and the custom mapper
                List<ZerodhaTradeableInstrumentDto> instruments;
                using (var reader = new StringReader(csvContent))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    ZerodhaTradeableInstrumentMapper.RegisterCsvMap(csv);
                    instruments = csv.GetRecords<ZerodhaTradeableInstrumentDto>().ToList();
                }

                // Map DTOs to Entities
                var entities = instruments.Select(ZerodhaTradeableInstrumentMapper.MapToEntity).ToList();

                // Save to DB
                await _repository.CreateAsync(entities);

                return $"Fetched, parsed, and saved {entities.Count} instruments successfully.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching Zerodha tradeable instruments");
                throw;
            }
        }

        public async Task<ZerodhaTradeableInstrumentDto?> GetInstrumentByTradingSymbolAndExchangeAsync(string tradingsymbol, string exchange)
        {
            try
            {
                var entity = await _repository.GetInstrumentByTradingSymbolAndExchangeAsync(tradingsymbol, exchange);
                if (entity == null)
                    return null;
                return Mapper.ZerodhaTradeableInstrumentMapper.MapToDto(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching instrument by tradingsymbol and exchange");
                throw;
            }
        }
    }
}
