using Core.Dto;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BaseService
    {
        private readonly ILogger<BaseService> _logger;

        public BaseService(ILogger<BaseService> logger)
        {
            _logger = logger;
        }

        protected async Task<ApiReponse> ExecuteSafeAsync(Func<Task<ApiReponse>> action, string errorMessage)
        {
            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{errorMessage} : {ex.Message}", ex);
                return ApiReponse.Error(errorMessage);
            }
        }
    }
}
