using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using EventFlow.Aggregates;
using EventFlow.Commands;

using Microsoft.EntityFrameworkCore.Storage;

namespace VehicleTracker.Business.VehicleDomain.Commands
{
    public class RegisterVehicleCommand : Command<VehicleAggregate, VehicleId> {
        public VehicleEntity VehicleEntity { get; }

        public RegisterVehicleCommand(VehicleEntity vehicleEntity) : base(VehicleId.New) {
            VehicleEntity = vehicleEntity;
        }
    }

    internal class RegisterVehicleCommandHandler : CommandHandler<VehicleAggregate, VehicleId, RegisterVehicleCommand> {


        public override Task ExecuteAsync(VehicleAggregate aggregate, RegisterVehicleCommand command, CancellationToken cancellationToken) {

            aggregate.CreateVehicle(command.VehicleEntity);

            return Task.CompletedTask;
        }
    }
}
