using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Photo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Photo photo Data
    /// </summary>
    public class Photo_Service : IPhoto_Service
    {
        //Reference to our crud functions
        private IPhoto_Operations _photo_operations = new Photo_Operations();

        /// <summary>
        /// Obtains all the Photo photoes that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Photo_ResultSet>>> GetAllPhotos()
        {
            Generic_ResultSet<List<Photo_ResultSet>> result = new Generic_ResultSet<List<Photo_ResultSet>>();
            try
            {
                //GET ALL Photo photoES
                List<Photo> Photoes = await _photo_operations.ReadAll();
                //MAP DB Photo RESULTS
                result.result_set = new List<Photo_ResultSet>();
                Photoes.ForEach(s =>
                {
                    result.result_set.Add(new Photo_ResultSet
                    {
                        photo_id = s.Photo_ID,
                        photo_name = s.Photo_Name,
                        photo_detail = s.Photo_Detail
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Photo photoes obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Photo_Service: GetAllPhotos() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Photo photoes from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Photo_Service: GetAllPhotos(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Photo_ResultSet>> GetPhotoById(long id)
        {
            Generic_ResultSet<Photo_ResultSet> result = new Generic_ResultSet<Photo_ResultSet>();
            try
            {
                //GET by ID Photo 
                var Photo = await _photo_operations.Read(id);

                //MAP DB Photo RESULTS
                result.result_set = new Photo_ResultSet
                {
                    photo_id = Photo.Photo_ID,
                    photo_name = Photo.Photo_Name,
                    photo_detail = Photo.Photo_Detail
                    
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Photo  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Photo_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Photo  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Photo_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new photo to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Photo_ResultSet>> AddPhoto(string photo_name, string photo_detail)
        {
            Generic_ResultSet<Photo_ResultSet> result = new Generic_ResultSet<Photo_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Photo
                Photo Photo = new Photo
                {
                    Photo_Name = photo_name,
                    Photo_Detail = photo_detail
                };

                //ADD Photo TO DB
                Photo = await _photo_operations.Create(Photo);

                //MANUAL MAPPING OF RETURNED Photo VALUES TO OUR Photo_ResultSet
                Photo_ResultSet photoAdded = new Photo_ResultSet
                {
                    photo_name = Photo.Photo_Name,
                    photo_detail = Photo.Photo_Detail,
                    photo_id = Photo.Photo_ID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Photo photo {0} was added successfully", photo_name);
                result.internalMessage = "LOGIC.Services.Implementation.Photo_Service: AddPhoto() method executed successfully.";
                result.result_set = photoAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Photo photo supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Photo_Service: AddPhoto(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an Photo photos name.
        /// </summary>
        /// <param name="photo_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Photo_ResultSet>> UpdatePhoto(Int64 photo_id, string photo_name, string photo_detail)
        {
            Generic_ResultSet<Photo_ResultSet> result = new Generic_ResultSet<Photo_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Photo
                Photo Photo = new Photo
                {
                    Photo_ID = photo_id,
                    Photo_Name = photo_name,
                    Photo_Detail = photo_detail
                    //Photo_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Photo IN DB
                Photo = await _photo_operations.Update(Photo, photo_id);

                //MANUAL MAPPING OF RETURNED Photo VALUES TO OUR Photo_ResultSet
                Photo_ResultSet photoUpdated = new Photo_ResultSet
                {
                    photo_name = Photo.Photo_Name,
                    photo_id = Photo.Photo_ID,
                    photo_detail = Photo.Photo_Detail
                    
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Photo photo {0} was updated successfully", photo_id);
                result.internalMessage = "LOGIC.Services.Implementation.Photo_Service: UpdatePhoto() method executed successfully.";
                result.result_set = photoUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Photo photo supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Photo_Service: UpdatePhoto(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeletePhoto(long photo_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {               
                //delete Photo IN DB
                var photoDeleted= await _photo_operations.Delete(photo_id);
                
                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Photo photo {0} was deleted successfully", photo_id);
                result.internalMessage = "LOGIC.Services.Implementation.Photo_Service: DeletePhoto() method executed successfully.";
                result.result_set = photoDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Photo photo supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Photo_Service: DeletePhoto(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
