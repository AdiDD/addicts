import fetcher from "../../utils/fetcher";
import {useEffect, useState} from "react";
import validator from "validator";
import isEmail = validator.isEmail;
import isStrongPassword = validator.isStrongPassword;
import {getDevToken} from "../../utils/jwtToken";

interface ISignUp {
  username: string,
  email: string,
  password: string,
}

const initialState = {
  warningU: "Please choose username",
  warningE: "Valid email address required",
  warningP: "At least 8 characters(1[Aa1@])",
}

const useSignUp = ({username, email, password}: ISignUp) => {
  const [{ warningU, warningE, warningP }, setState] = useState(initialState);

  const clearState = () => {
    setState({ ...initialState });
  };

  // useEffect(() => {
  //   if (username.length !== 0) {
  //     let token = getDevToken();
  //     fetcher({url: `/client/check/username/${username}`, headers: {Authorization: `Bearer ${token}`}})
  //       .then(res => {
  //         if (res === 'Already registered')
  //           setState((prevState) => ({ ...prevState, warningU: "Username already registered!" }));
  //         else
  //           setState((prevState) => ({ ...prevState, warningU: "Look's good!" }));
  //       })
  //   } else {
  //     setState((prevState) => ({ ...prevState, warningU: initialState.warningU }));
  //   }
  // }, [username.length])

  useEffect(() => {
    if (isEmail(email)) {
      fetcher({url: `/account/check-email/${email}`, headers: {Authorization: `Bearer ${getDevToken()}`}})
        .then(res => {
          if (res !== 'Accepted')
            setState((prevState) => ({ ...prevState, warningE: "Email address already registered!" }));
          else
            setState((prevState) => ({ ...prevState, warningE: "Look's good!" }));
        })
    } else {
      setState((prevState) => ({...prevState, warningE: initialState.warningE}));
    }
  }, [email.length])

  useEffect(() => {
    if (!isStrongPassword(password))
      setState((prevState) => ({...prevState, warningP: initialState.warningP}));
    else
      setState((prevState) => ({ ...prevState, warningP: "Look's good!" }));

  }, [password.length])

  const isValidSubmit = warningU.includes("good") && warningE.includes("good") && warningP.includes("good");

  return { warningU, warningE, warningP, clearState, isValidSubmit }
}

export default useSignUp;