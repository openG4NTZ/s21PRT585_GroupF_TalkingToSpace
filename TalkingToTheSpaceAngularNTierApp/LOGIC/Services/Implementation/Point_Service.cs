using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Point;

namespace LOGIC.Services.Implementation
{
    public class Point_Service : IPoint_Service
    {
        //Reference to our crud functions
        private IPoint_Operations _point_operations = new Point_Operations();

        public async Task<Generic_ResultSet<List<Point_ResultSet>>> GetAllPoints()
        {
            Generic_ResultSet<List<Point_ResultSet>> result = new Generic_ResultSet<List<Point_ResultSet>>();
            try
            {
                //GET ALL Point pointES
                List<Point> Pointes = await _point_operations.ReadAll();
                //MAP DB Point RESULTS
                result.result_set = new List<Point_ResultSet>();
                Pointes.ForEach(m =>
                {
                    result.result_set.Add(new Point_ResultSet
                    {
                        point_id = m.Point_ID,
                        point_amount = m.Point_Amount,
                        user_id = m.User_ID
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Point pointes obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Point_Service: GetAllPoints() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Point pointes from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Point_Service: GetAllPoints(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Point_ResultSet>> GetPointByPointId(long point_id)
        {
            Generic_ResultSet<Point_ResultSet> result = new Generic_ResultSet<Point_ResultSet>();
            try
            {
                //GET by ID Point 
                var Point = await _point_operations.Read(point_id);

                //MAP DB Point RESULTS
                result.result_set = new Point_ResultSet
                {
                    point_id = Point.Point_ID,
                    point_amount = Point.Point_Amount,
                    user_id = Point.User_ID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Point  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Point_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Point  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Point_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }




        public async Task<Generic_ResultSet<Point_ResultSet>> AddPoint(string point_amount, Int64 user_id)
        {
            Generic_ResultSet<Point_ResultSet> result = new Generic_ResultSet<Point_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Point
                Point Point = new Point
                {
                    Point_Amount = point_amount,
                    User_ID = user_id
                };

                //ADD Point TO DB
                Point = await _point_operations.Create(Point);

                //MANUAL MAPPING OF RETURNED Point VALUES TO OUR Point_ResultSet
                Point_ResultSet pointAdded = new Point_ResultSet
                {
                    point_id = Point.Point_ID,
                    point_amount = Point.Point_Amount,
                    user_id = Point.User_ID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Point point {0} was added successfully", point_amount);
                result.internalMessage = "LOGIC.Services.Implementation.Point_Service: AddPoint() method executed successfully.";
                result.result_set = pointAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Point point supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Point_Service: AddPoint(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        public async Task<Generic_ResultSet<Point_ResultSet>> UpdatePoint(Int64 point_id, string point_amount, Int64 user_id)
        {
            Generic_ResultSet<Point_ResultSet> result = new Generic_ResultSet<Point_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Point
                Point Point = new Point
                {
                    Point_ID = point_id,
                    Point_Amount = point_amount,
                    User_ID = user_id
                };

                //UPDATE Point IN DB
                Point = await _point_operations.Update(Point, point_id);

                //MANUAL MAPPING OF RETURNED Point VALUES TO OUR Point_ResultSet
                Point_ResultSet pointUpdated = new Point_ResultSet
                {
                    point_id = Point.Point_ID,
                    point_amount = Point.Point_Amount,
                    user_id = Point.User_ID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Point point {0} was updated successfully", point_amount);
                result.internalMessage = "LOGIC.Services.Implementation.Point_Service: UpdatePoint() method executed successfully.";
                result.result_set = pointUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Point point supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Point_Service: UpdatePoint(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeletePoint(long point_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Point IN DB
                var pointDeleted = await _point_operations.Delete(point_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Point point {0} was deleted successfully", point_id);
                result.internalMessage = "LOGIC.Services.Implementation.Point_Service: DeletePoint() method executed successfully.";
                result.result_set = pointDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Point point supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Point_Service: DeletePoint(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


    }
}


