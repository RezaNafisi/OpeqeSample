using Opeqe.Sample.Common.Log;
using Opeqe.Sample.Common.Models;
using Opeqe.Sample.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opeqe.Sample.DAL.Repository
{
    public class Commands
    {
        UnitOfWork unitOfWork;
        public Commands()
        {
            unitOfWork = new UnitOfWork();
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public async Task<ReturnValue> Register(RegisterModel model)
        {
            try
            {
                if (!IsValidEmail(model.Email))
                {
                    return new ReturnValue
                    {
                        IsSuccessful = false,
                        Message = "Email is not valid"
                    };
                }
                if (model.Password.Length<6)
                {
                    return new ReturnValue
                    {
                        IsSuccessful = false,
                        Message = "Minimum password length should be 6."
                    };
                }
                if (model.Password!=model.ConfirmPassword)
                {
                    return new ReturnValue
                    {
                        IsSuccessful = false,
                        Message = "The password is not the same as its confirm"
                    };
                }

                var res = await unitOfWork.UserRepository.GetAsync(g => g.Username == model.Email);
                if (res!=null && res.Count()>0)
                {
                    return new ReturnValue
                    {
                        IsSuccessful = false,
                        Message = "User is exist."
                    };
                }
                var id = 0;
                var lastUser = await unitOfWork.UserRepository.GetAsync();
                if (lastUser!=null && lastUser.LastOrDefault()!=null)
                {
                    id = lastUser.LastOrDefault().UserId + 1;
                }
                var user = new User
                {
                    UserId = id,//Auto increment by DB
                    Email = model.Email,
                    Name = model.Name,
                    Password = model.Password,
                    Username = model.Email
                };
                await unitOfWork.UserRepository.InsertAsync(user);
                return new ReturnValue
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                await ExceptionHandling.HandleAsync(ex);
                return new ReturnValue
                {
                    IsSuccessful = false,
                    Message = "An error has occurred. Please check the log."
                };
            }
        }

        public async Task<ReturnValue<bool>> LoginAsync(string username,string password)
        {
            try
            {
                if (!IsValidEmail(username))
                {
                    return new ReturnValue<bool>
                    {
                        IsSuccessful = true,
                        Message = "Email is not valid",
                        Data=false
                    };
                }
                var user = await unitOfWork.UserRepository.GetAsync(g=>g.Username==username && g.Password==password);
                if (user==null)
                {
                    return new ReturnValue<bool>
                    {
                        Data = false,
                        IsSuccessful = true,
                        Message = "Incorrect username or password."
                    };
                }
                return new ReturnValue<bool> 
                {
                    IsSuccessful = true,
                    Data=true
                };
            }
            catch (Exception ex)
            {
                await ExceptionHandling.HandleAsync(ex);
                return new ReturnValue<bool>
                {
                    IsSuccessful = false,
                    Message = "An error has occurred. Please check the log."
                };
            }
        }

        public async Task<ReturnValue> AddRequest(string username,Distance distance)
        {
            try
            {
                var user = await unitOfWork.UserRepository.GetAsync(g => g.Username == username);
                if (user==null || user.Count()==0)
                {
                    return new ReturnValue
                    {
                        IsSuccessful = false,
                        Message = "User does not exist."
                    };
                }

                var request = new Request
                {
                    Distance = distance,
                    DateTime = DateTime.Now,
                    RequestId = 0,//Auto increment by DB
                    UserId = user.FirstOrDefault().UserId
                };

                await unitOfWork.RequestRepository.InsertAsync(request);

                return new ReturnValue
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                await ExceptionHandling.HandleAsync(ex);
                return new ReturnValue
                {
                    IsSuccessful = false,
                    Message = "An error has occurred. Please check the log."
                };
            }
        }
        
        public async Task<ReturnValue<IEnumerable<Request>>> GetRequest(string username)
        {
            try
            {
                var user = await unitOfWork.UserRepository.GetAsync(g => g.Username == username);
                if (user == null || user.Count() == 0)
                {
                    return new ReturnValue<IEnumerable<Request>>
                    {
                        IsSuccessful = false,
                        Message = "User does not exist."
                    };
                }


                var res = await unitOfWork.RequestRepository.GetAsync(g=>g.UserId==user.FirstOrDefault().UserId);

                return new ReturnValue<IEnumerable<Request>>
                {
                    IsSuccessful = true,
                    Data=res
                };
            }
            catch (Exception ex)
            {
                await ExceptionHandling.HandleAsync(ex);
                return new ReturnValue<IEnumerable<Request>>
                {
                    IsSuccessful = false,
                    Message = "An error has occurred. Please check the log."
                };
            }
        }
    }
}
