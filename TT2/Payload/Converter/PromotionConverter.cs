using TT2.Entity;
using TT2.Payload.DataResponse;

namespace TT2.Payload.Converter
{
    public class PromotionConverter
    {
        public readonly App_DBcontext dbcontext;
        public PromotionConverter()
        {
            dbcontext = new App_DBcontext();
        }
        public DataResponse_Promotion EntityToDTO(Promotion promotion)
        {
            return new DataResponse_Promotion()
            {
                Percent = promotion.Percent,
                Quantity = promotion.Quantity,
                Type = promotion.Type,
                StartTime = promotion.StartTime,
                EndTime = promotion.EndTime,
                Description = promotion.Description,
                Name = promotion.Name,
            };
        }
    }
}
