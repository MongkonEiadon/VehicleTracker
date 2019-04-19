using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using Domain.Application.CommandServices;
using Domain.Application.QueryServices;
using Domain.Business.Vehicles;
using Domain.Business.Vehicles.Commands;

using EventFlow;

using Microsoft.AspNetCore.Mvc;

using Vehicles.Service.ViewModels;

namespace Vehicles.Service.Controllers {
    [Route("Vehicle")]
    [ApiController]
    public class VehiclesController : Controller {
        private readonly IMapper _mapper;
        private readonly IVehicleQueryService _vehicleQueryService;
        private readonly ICommandBus _commandBus;

        public VehiclesController(IVehicleQueryService vehicleQueryService, 
            
            ICommandBus commandBus, IMapper mapper) {
            _vehicleQueryService = vehicleQueryService;
            _commandBus = commandBus;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicle(string id, CancellationToken cancellationToken) {
            if (string.IsNullOrEmpty(id))
                return BadRequest(nameof(NullReferenceException));


            var result = await _vehicleQueryService.GetVehicleByIdAsync(VehicleId.With(Guid.Parse(id)), cancellationToken);
            return new JsonResult(result);
        }


        [HttpPost]
        public async Task<IActionResult> StoreVehicle(VehicleViewModel vehicleViewModel,
            CancellationToken cancellationToken) {


            await _commandBus.PublishAsync(
                new RegisterVehicleCommand(vehicleViewModel.LicensePlateNumber, vehicleViewModel.Model,
                    vehicleViewModel.Country),
                cancellationToken);


            return Ok();
        }
    }
}