using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EventFlow;
using EventFlow.Queries;
using Microsoft.AspNetCore.Mvc;
using Vehicle.ReadStore;
using Vehicle7Tracker.Domain.Application.QueryServices;
using Vehicle7Tracker.Domain.Business.VehicleDomain;

namespace Vehicle.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly IVehicleQueryService _vehicleQueryService;

        public VehicleController(IVehicleQueryService vehicleQueryService)
        {
            _vehicleQueryService = vehicleQueryService;
        }


        public async Task<IActionResult> GetVehicle(string id, CancellationToken cancellationToken)
        {
            var result = await _vehicleQueryService.GetVehicleByIdAsync(VehicleId.With(id), cancellationToken);
            return new JsonResult(result);
        }
    }
}
