import Modal from "../components/ui/Modal";
import {MdOutlineEmail, MdPassword} from "react-icons/md";
import {closeModal, switchModal} from "../utils/handleModal";
import {FormEvent, useEffect, useState} from "react";
import useSignIn from "./hooks/useSignIn";
import {showToast} from "../utils/handleToast";
import storage from "../utils/localStorage";
// import {mutate} from 'swr';

const id = "signIn";

const initialState = {
  email: "",
  password: "",
  invalidCredentials: false,
}

const SignIn = () => {
  const [{ email, password, invalidCredentials }, setState] = useState(initialState);
  const { response, clearResponse } = useSignIn({email, password});

  const clearState = () => {
    setState({ ...initialState });
  };

  const handleSubmit = (event: FormEvent) => {
    event.preventDefault();
    setState((prevState) => ({
      ...prevState,
      email: (document.getElementById("email") as HTMLInputElement).value,
      password: (document.getElementById("password") as HTMLInputElement).value,
    }))
  }

  useEffect(() => {
    setState((prevState) => ({...prevState, invalidCredentials: response.status === 403}));

    if (response.status === 200) {
      storage("setItem", "userId", response.userId);
      storage("setItem", "userToken", response.token);
      closeModal(`#${id}`, clearState);
      clearResponse();
      showToast("#welcome", response.username)
      // mutate("/client/get")
      //   .then(() => showToast("#welcome", response.username));
    }
  }, [response])

  return (
    <Modal
      title={"Login"}
      inputs={
        [
          {label: "E-Mail Address", id: "email", icon: <MdOutlineEmail />, type: "email"},
          {label: "Password", id: "password", icon: <MdPassword />, type: "password"},
        ]
      }
      handleSubmit={handleSubmit}
      submitBtnTitle={"Login"}
      switchQuestion={"You don't have an account?"}
      handleSwitch={() => switchModal(`#${id}`, "#signUp", clearState)}
      modalId={id}
      close={() => closeModal(`#${id}`, clearState)}
      invalidCredentials={invalidCredentials}
    />
  );
};

export default SignIn;