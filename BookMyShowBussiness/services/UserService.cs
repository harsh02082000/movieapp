using BookMyShowData.Repository;
using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowBussiness.services
{
    public class UserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }
        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }
        public void DeleteUser(int userId)
        {
            _userRepository.DeleteUser(userId);
        }
      
        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }
        public User GetUserByid(int userId)
        {
            return _userRepository.GetUserById(userId);
        }
    }
}
