using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using Domain.Application.CommandServices;
using Domain.Application.QueryServices;
using Domain.Business.Vehicles;

using Microsoft.AspNetCore.Mvc;


namespace Trackers.Service.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class TrackingController : Controller {
        private readonly IMapper _mapper;
        private readonly ITrackingQueryService _trackingQueryService;
        private readonly ITrackingCommandService _trackingCommandService;

        public TrackingController(ITrackingQueryService trackingQueryService, ITrackingCommandService trackingCommandService,  IMapper mapper) {
            _trackingQueryService = trackingQueryService;
            _trackingCommandService = trackingCommandService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicle(Guid vehicleId, CancellationToken cancellationToken) {

            var result = await _trackingQueryService.GetCurrentVehicleLocationAsync(VehicleId.With(vehicleId), cancellationToken);
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLocation(Guid vehicleId, double latitude, double longitude, double zindex, CancellationToken ctx) {

            await _trackingCommandService.StoreVehicleLocationAsync(vehicleId, latitude, longitude, zindex, ctx);
            return Ok($"Store new location for vehicle id {vehicleId} completed");
        }
    }

}