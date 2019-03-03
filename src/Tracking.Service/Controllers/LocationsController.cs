using System;
using System.Linq;
using System.Net;
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
        [Route("{vehicleId}")]
        public async Task<IActionResult> GetAllLocation(Guid vehicleId, CancellationToken cancellationToken)
        {
            var result = await _trackingQueryService.GetLocationHistoryAsync(VehicleId.With(vehicleId), cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        [Route("{vehicleId}/{from}/{to}")]
        public async Task<IActionResult> GetLocationWithCertainTime(Guid vehicleId, DateTimeOffset from,
            DateTimeOffset to, CancellationToken cancellationToken) {

            var result = await _trackingQueryService.GetLocationHistoryAsync(VehicleId.With(vehicleId), cancellationToken);
            var peroid = result.OrderBy(x => x.TimeStamp).Where(x => x.TimeStamp >= from && x.TimeStamp <= to);

            return Ok(peroid);

        }

    }

}