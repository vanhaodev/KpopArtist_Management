using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistMNG.Module
{
    /// <summary>
    /// Ý tưởng là khi hành động mở form 2 ở form 1
    /// gọi isLoaded = false và chạy while đến khi form 2 load xong sẽ 
    /// set isLoaded thành true và điều kiện để đóng form load
    /// </summary>
    public static class FormLoad
    {
        public static bool isLoaded;
    }
}
