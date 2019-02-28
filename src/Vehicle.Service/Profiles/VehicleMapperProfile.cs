using AutoMapper;

using Vehicle.Service.ViewModels;

using VehicleTracker.Business.VehicleDomain;

namespace Vehicle.Service.Profiles {
    public class VehicleMapperProfile : Profile {
        public VehicleMapperProfile() {
            CreateMap<VehicleViewModel, VehicleEntity>()
                .BeforeMap((vm, m) => {
                    var id = string.IsNullOrWhiteSpace(vm.Id) ? VehicleId.New : VehicleId.With(vm.Id);
                    m = new VehicleEntity(id);
                })
                .ReverseMap();
        }
    }
}