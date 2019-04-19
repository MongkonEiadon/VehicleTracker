using System.Threading;
using System.Threading.Tasks;

using EventFlow.Commands;

namespace Domain.Business.Vehicles.Commands {

    public class VehicleRegisterCompleteCommand : Command<VehicleAggregate, VehicleId> {

        public VehicleEntity Entity { get; }

        public VehicleRegisterCompleteCommand(VehicleEntity entity) : base(entity.Id) {
            Entity = entity;
        }

    }

    internal class VehicleRegisterCompleteCommandHandler : CommandHandler<VehicleAggregate, VehicleId, VehicleRegisterCompleteCommand> {

        public override Task ExecuteAsync(VehicleAggregate aggregate, VehicleRegisterCompleteCommand command,
            CancellationToken cancellationToken) {

            aggregate.RegisterComplete(command.Entity);

            return Task.CompletedTask;
        }

    }

}