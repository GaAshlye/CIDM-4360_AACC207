using System;

namespace ValidationLib
{
    public class LoginValidator
    {
        /*
        Business Rules:
        validpassword:
        1) Must be eight characters in length
        2) Must contain at least one lower-case letter
        3) Must contain at least one upper-case letter
        */
        public static bool ValidatePassword(string password)
        {
            bool seemslegit = true;
            bool haslower = false;
            bool hasupper = false;

            char[] inputarray = password.ToCharArray();

            //1) Must be eight characters in length
            if(inputarray.Length < 8)
            {
                seemslegit = false;
                throw new Exception("Password is too short");
            }

            //2) Must contain at least one lower-case letter
            foreach(char c in inputarray)
            {
                if(char.IsLower(c))
                {
                    haslower = true;
                    break;
                }
            }

            //there wasn't a single lower-case letter, throw exception
            if(!haslower){
                throw new Exception("Password does not contain at least one lower-case letter");                
            }

            //3) Must contain at least one upper-case letter
            foreach(char c in inputarray)
            {
                if(char.IsUpper(c))
                {
                    hasupper = true;
                    break;
                }
            }
            
            //there wasn't a single upper-case letter, throw exception
            if(!hasupper){
                throw new Exception("Password does not contain at least one upper-case letter");
            }

            seemslegit = haslower && hasupper ? true : false;

            return seemslegit;

        }

        /*
        Business Rules:
        valid email address:
        1) must not begin or end with a '.'
        2) must not begin or end with a '@'
        3) from the back of the string, the '.' must come before the '@'
        4) '.' can appear before the '@' at the beginning of the string
        */
        public static bool ValidateUsername(string username)
        {
            bool seemslegit = true;

            char[] inputarray = username.ToCharArray();
            
            //1) must not begin or end with a '.'
            if(inputarray[0] == '.' || inputarray[inputarray.Length - 1] == '.')
            {
                seemslegit = false;
                return seemslegit;
            }

            //2) must not begin or end with a '@'
            if(inputarray[0] == '@' || inputarray[inputarray.Length - 1] == '@')
            {
                seemslegit = false;
                return seemslegit;
            }            

            //3) from the back of the string, the '.' must come before the '@'
            int atpos = FindCharInArray(inputarray, '@');
            int dotpos = FindCharInArray(inputarray, '.');
            if(dotpos < atpos){
                seemslegit = false;
            }

            return seemslegit;
        }

        private static int FindCharInArray(char[] input, char c)
        {
            int index = -999;

            //count backwards
            for(int i = input.Length; i < 0; i--)
            {
                if(input[i] == index){
                    index = i;
                    return index;
                }
            }

            return index;
        }
    }
}
