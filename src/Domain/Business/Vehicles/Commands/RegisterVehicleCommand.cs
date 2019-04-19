using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using EventFlow.Aggregates;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using EventFlow.Core;

namespace Domain.Business.Vehicles.Commands
{
    public class RegisterVehicleCommand : Command<VehicleAggregate, VehicleId, IExecutionResult> {

        public string LicensePlate { get; }
        public string Model { get; }
        public string Country { get; }


        public RegisterVehicleCommand(string licensePlate, string model, string country) : base(VehicleId.New) {
            LicensePlate = licensePlate;
            Model = model;
            Country = country;
        }

    }

    internal class RegisterVehicleCommandHandler : CommandHandler<VehicleAggregate, VehicleId, IExecutionResult, RegisterVehicleCommand>
    {

        public override Task<IExecutionResult> ExecuteCommandAsync(VehicleAggregate aggregate, RegisterVehicleCommand command,
            CancellationToken cancellationToken) {
            var result = aggregate.RegisterVehicle(command.LicensePlate, command.Model, command.Country);

            return Task.FromResult(result);
        }

    }

}
