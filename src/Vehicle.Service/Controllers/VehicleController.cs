using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using Vehicle.Service.ViewModels;

using VehicleTracker.Application.QueryServices;
using VehicleTracker.Business.VehicleDomain;

namespace Vehicle.Service.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VehiclesController : Controller {
        private readonly IMapper _mapper;
        private readonly IVehicleQueryService _vehicleQueryService;

        public VehiclesController(IVehicleQueryService vehicleQueryService, IMapper mapper) {
            _vehicleQueryService = vehicleQueryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicle(string id, CancellationToken cancellationToken) {
            if (string.IsNullOrEmpty(id))
                return BadRequest(nameof(NullReferenceException));


            var result =
                await _vehicleQueryService.GetVehicleByIdAsync(VehicleId.With(Guid.Parse(id)), cancellationToken);
            return new JsonResult(result);
        }


        [HttpPost]
        public async Task<IActionResult> StoreVehicle(VehicleViewModel vehicleViewModel,
            CancellationToken cancellationToken) {
            var vehicle = _mapper.Map<VehicleEntity>(vehicleViewModel);


            return Ok();
        }
    }
}