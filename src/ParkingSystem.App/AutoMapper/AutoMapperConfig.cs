using AutoMapper;
using ParkingSystem.App.ViewModels;
using ParkingSystem.Model;

namespace ParkingSystem.App.AutoMapper
{
	public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig()
		{
			CreateMap<Carro, CarroViewModel>().ReverseMap();
			CreateMap<Manobrista, ManobristaViewModel>().ReverseMap();
		}
	}
}
