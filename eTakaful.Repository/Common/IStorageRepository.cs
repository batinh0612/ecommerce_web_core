using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Common
{
    public interface IStorageRepository
    {
        /// <summary>
        /// Get file url
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        string GetFileUrl(string fileName);

        /// <summary>
        /// Save file async
        /// </summary>
        /// <param name="mediaBinaryStream"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Task SaveFileAsync(Stream mediaBinaryStream, string fileName);

        /// <summary>
        /// Delete file async
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Task DeleteFileAsync(string fileName);
    }
}
