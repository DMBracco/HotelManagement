using HotelManagement.ViewModel;

namespace HotelManagement.BLL.IServices
{
    public interface IStatusRoomService
    {
        Task<List<StatusRoomViewModel>> StatusRoomsAsync();
    }
}
