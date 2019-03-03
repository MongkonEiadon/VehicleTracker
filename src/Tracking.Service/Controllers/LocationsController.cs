using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using VehicleTracker.Application.QueryServices;
using VehicleTracker.Business.VehicleDomain;

namespace Tracking.Service.Controllers {

    [Route("api/v1/[controller]")]
    [ApiController]
    public class LocationsController : Controller {

        private readonly ITrackingQueryService _trackingQueryService;

        public LocationsController(ITrackingQueryService trackingQueryService) {
            _trackingQueryService = trackingQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocation(Guid vehicleId, CancellationToken cancellationToken)
        {
            var result = await _trackingQueryService.GetLocationHistoryAsync(VehicleId.With(vehicleId), cancellationToken);

            return Ok(result);
        }

    }

}