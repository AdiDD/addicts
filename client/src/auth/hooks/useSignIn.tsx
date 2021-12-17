import {useEffect, useState} from "react";
import fetcher from "../../utils/fetcher";
import validator from "validator";
import isEmail = validator.isEmail;
import isStrongPassword = validator.isStrongPassword;

interface ISignIn {
  email: string,
  password: string,
}

const initialState = {
  userId: "", username: "", token: "", status: -1
}

const useSignIn = ({email, password}: ISignIn) => {
  const [response, setResponse] = useState(initialState);

  const clearResponse = () => {
    setResponse({ ...initialState });
  };

  useEffect(() => {
    if (isEmail(email) && isStrongPassword(password)) {
      fetcher({
        url: "/account/login",
        method: "post",
        data: {email: email, password: password}
      })
        .then(res => setResponse(res))
        .catch(err => setResponse(err.response))
    }
  }, [email, password])

  return {response, clearResponse}
}

export default useSignIn;