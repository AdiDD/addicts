import Modal from "../components/ui/Modal";
import {AiOutlineUser} from "react-icons/ai";
import {MdOutlineEmail, MdPassword} from "react-icons/md";
import {closeModal, switchModal} from "../utils/handleModal";
import {FormEvent, useState} from "react";
import useSignUp from "./hooks/useSignUp";
import fetcher from "../utils/fetcher";
import {showToast} from "../utils/handleToast";

const id = "signUp";

const SignUp = () => {
  const [username, setUsername] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const {warningU, warningE, warningP, clearState, isValidSubmit} = useSignUp({username, email, password});

  const handleSubmit = (event: FormEvent) => {
    event.preventDefault();
    if (isValidSubmit) {
      fetcher({
        url: "/auth/register",
        method: "post",
        data: {username: username, email: email, password: password}
      })
        .then(() => {
          switchModal(`#${id}`, "#signIn", clearState);
          showToast("#created");
        })
        .catch((err) => {
          console.log(err);
          showToast("#error");
        })
    }
  }

  return (
      <Modal
        title={"Create Account"}
        inputs={
          [
            {label: "Username", id: "username", icon: <AiOutlineUser />, type: "text", setValue: setUsername, warning: warningU},
            {label: "E-Mail Address", id: "emailUp", icon: <MdOutlineEmail />, type: "email", setValue: setEmail, warning: warningE},
            {label: "Password", id: "passwordUp", icon: <MdPassword />, type: "password", setValue: setPassword, warning: warningP},
          ]
        }
        handleSubmit={handleSubmit}
        submitBtnTitle={"Join us"}
        switchQuestion={"Already a user?"}
        handleSwitch={() => switchModal(`#${id}`, "#signIn", clearState)}
        modalId={id}
        close={() => {
          closeModal(`#${id}`, clearState)
        }}
      />
  );
};

export default SignUp;