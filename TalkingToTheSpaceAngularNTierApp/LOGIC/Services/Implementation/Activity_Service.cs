using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Activity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Activity activity Data
    /// </summary>
    public class Activity_Service : IActivity_Service
    {
        //Reference to our crud functions
        private IActivity_Operations _activity_operations = new Activity_Operations();

        /// <summary>
        /// Obtains all the Activity activityes that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Activity_ResultSet>>> GetAllActivitys()
        {
            Generic_ResultSet<List<Activity_ResultSet>> result = new Generic_ResultSet<List<Activity_ResultSet>>();
            try
            {
                //GET ALL Activity activityES
                List<Activity> Activityes = await _activity_operations.ReadAll();
                //MAP DB Activity RESULTS
                result.result_set = new List<Activity_ResultSet>();
                Activityes.ForEach(s =>
                {
                    result.result_set.Add(new Activity_ResultSet
                    {
                        activity_id = s.Activity_ID,
                        activity_creation_time = s.Activity_Creation_Time,
                        activity_detail = s.Activity_Detail
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Activity activityes obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Activity_Service: GetAllActivitys() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Activity activityes from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Activity_Service: GetAllActivitys(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Activity_ResultSet>> GetActivityById(long id)
        {
            Generic_ResultSet<Activity_ResultSet> result = new Generic_ResultSet<Activity_ResultSet>();
            try
            {
                //GET by ID Activity 
                var Activity = await _activity_operations.Read(id);

                //MAP DB Activity RESULTS
                result.result_set = new Activity_ResultSet
                {
                    activity_id = Activity.Activity_ID,
                    activity_creation_time = Activity.Activity_Creation_Time,
                    activity_detail = Activity.Activity_Detail
                    
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Activity  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Activity_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Activity  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Activity_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new activity to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Activity_ResultSet>> AddActivity(string creation_time, string creation_detail)
        {
            Generic_ResultSet<Activity_ResultSet> result = new Generic_ResultSet<Activity_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Activity
                Activity Activity = new Activity
                {
                    Activity_Creation_Time = creation_time,
                    Activity_Detail = creation_detail
                };

                //ADD Activity TO DB
                Activity = await _activity_operations.Create(Activity);

                //MANUAL MAPPING OF RETURNED Activity VALUES TO OUR Activity_ResultSet
                Activity_ResultSet activityAdded = new Activity_ResultSet
                {
                    activity_creation_time = Activity.Activity_Creation_Time,
                    activity_detail = Activity.Activity_Detail,
                    activity_id = Activity.Activity_ID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Activity activity {0} was added successfully", creation_time);
                result.internalMessage = "LOGIC.Services.Implementation.Activity_Service: AddActivity() method executed successfully.";
                result.result_set = activityAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Activity activity supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Activity_Service: AddActivity(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an Activity activitys name.
        /// </summary>
        /// <param name="activity_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Activity_ResultSet>> UpdateActivity(Int64 activity_id, string creation_time, string creation_detail)
        {
            Generic_ResultSet<Activity_ResultSet> result = new Generic_ResultSet<Activity_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Activity
                Activity Activity = new Activity
                {
                    Activity_ID = activity_id,
                    Activity_Creation_Time = creation_time,
                    Activity_Detail = creation_detail
                    //Activity_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Activity IN DB
                Activity = await _activity_operations.Update(Activity, activity_id);

                //MANUAL MAPPING OF RETURNED Activity VALUES TO OUR Activity_ResultSet
                Activity_ResultSet activityUpdated = new Activity_ResultSet
                {
                    activity_creation_time = Activity.Activity_Creation_Time,
                    activity_id = Activity.Activity_ID,
                    activity_detail = Activity.Activity_Detail
                    
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Activity activity {0} was updated successfully", creation_time);
                result.internalMessage = "LOGIC.Services.Implementation.Activity_Service: UpdateActivity() method executed successfully.";
                result.result_set = activityUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Activity activity supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Activity_Service: UpdateActivity(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteActivity(long activity_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {               
                //delete Activity IN DB
                var activityDeleted= await _activity_operations.Delete(activity_id);
                
                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Activity activity {0} was deleted successfully", activity_id);
                result.internalMessage = "LOGIC.Services.Implementation.Activity_Service: DeleteActivity() method executed successfully.";
                result.result_set = activityDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Activity activity supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Activity_Service: DeleteActivity(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
