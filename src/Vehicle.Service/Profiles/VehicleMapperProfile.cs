using AutoMapper;

using Vehicle.Service.ViewModels;

using VehicleTracker.Business.VehicleDomain;

namespace Vehicle.Service.Profiles {
    public class VehicleMapperProfile : Profile {
        public VehicleMapperProfile() {
            CreateMap<VehicleViewModel, VehicleEntity>()
                .ConstructUsing(x => new VehicleEntity(string.IsNullOrEmpty(x.Id) ? VehicleId.New : VehicleId.With(x.Id)));

        }
    }
}