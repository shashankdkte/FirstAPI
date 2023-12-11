using FirstAPI.Models.DTO;

namespace FirstAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>{
            new VillaDTO{Id= 1, Name="Beach View"},
            new VillaDTO{Id= 2,Name="Pool View"},
        };

    }
}
