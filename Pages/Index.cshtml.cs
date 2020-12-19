using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using waveapps.Client;

namespace waveapps.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly WaveappsClient _client;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _client = new WaveappsClient();
        }

        public async Task OnGetAsync()
        {
            await _client.GetAllUsers();
        }
    }
}
