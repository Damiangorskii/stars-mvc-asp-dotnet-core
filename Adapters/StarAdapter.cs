using gwiazdy.Models;
using stars_database.Models;

namespace gwiazdy.Adapters
{
    public class StarAdapter
    {
        public static StarDTO ConvertToDTO(Star star)
        {
            return new StarDTO
            {
                Id = star.Id,
                Name = star.Name,
                Constellation = star.Constellation,
                Magnitude = star.Magnitude,
                Distance = star.Distance,
                SpectralType = star.SpectralType,
                Mass = star.Mass,
                Radius = star.Radius,
                Luminosity = star.Luminosity,
                Description = star.Description
            };
        }

        public static Star ConvertToEntity(StarDTO starDTO)
        {
            return new Star
            {
                Id = starDTO.Id,
                Name = starDTO.Name,
                Constellation = starDTO.Constellation,
                Magnitude = starDTO.Magnitude,
                Distance = starDTO.Distance,
                SpectralType = starDTO.SpectralType,
                Mass = starDTO.Mass,
                Radius = starDTO.Radius,
                Luminosity= starDTO.Luminosity,
                Description = starDTO.Description
            };
        }
    }

}
