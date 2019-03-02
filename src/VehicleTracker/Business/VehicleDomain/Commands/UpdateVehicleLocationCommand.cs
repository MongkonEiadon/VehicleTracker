using System.Threading;
using System.Threading.Tasks;

using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;

namespace VehicleTracker.Business.VehicleDomain.Commands {

    public class UpdateVehicleLocationCommand : Command<VehicleAggregate, VehicleId, IExecutionResult> {

        public double Latitude { get; }
        public double Longitude { get; }
        public double ZIndex { get;  }

        public UpdateVehicleLocationCommand(VehicleId aggregateId, double latitude, double longitude, double zindex) : base(aggregateId) {
            Latitude = latitude;
            Longitude = longitude;
            ZIndex = zindex;
        }
    }

    internal class UpdateVehicleLocationCommandHandler : CommandHandler<VehicleAggregate, VehicleId, IExecutionResult, UpdateVehicleLocationCommand> {

        public override Task<IExecutionResult> ExecuteCommandAsync(VehicleAggregate aggregate, UpdateVehicleLocationCommand command,
            CancellationToken cancellationToken) {

            return Task.FromResult(aggregate.UpdateVehicleLocation(command.Latitude, command.Longitude, command.ZIndex));
        }

    }

}