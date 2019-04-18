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
        public VehicleEntity VehicleEntity { get; }

        public RegisterVehicleCommand(VehicleEntity vehicleEntity) : base(vehicleEntity.Id) {
            VehicleEntity = vehicleEntity;
        }
    }

    internal class RegisterVehicleCommandHandler : CommandHandler<VehicleAggregate, VehicleId, IExecutionResult, RegisterVehicleCommand>
    {

        public override Task<IExecutionResult> ExecuteCommandAsync(VehicleAggregate aggregate, RegisterVehicleCommand command,
            CancellationToken cancellationToken)
        {
            var result = aggregate.CreateVehicle(command.VehicleEntity);

            return Task.FromResult(result);
        }

    }

}
