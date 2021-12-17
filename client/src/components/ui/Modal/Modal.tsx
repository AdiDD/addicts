import styles from "./Modal.module.css";
import {GiBottomRight3DArrow} from "react-icons/gi";
import {Dispatch, FormEventHandler, MouseEventHandler, SetStateAction} from "react";
import {AiFillCloseCircle} from "react-icons/ai";
import {IoMdLogIn} from "react-icons/io"
import cn from "classnames";

interface IInputs {
  label: string,
  id: string,
  icon: JSX.Element,
  type: string,
  setValue?: Dispatch<SetStateAction<string>>,
  warning?: string
}

interface IModalProps {
  title: string,
  inputs: IInputs[],
  handleSubmit: FormEventHandler,
  submitBtnTitle: string,
  switchQuestion: string,
  handleSwitch: MouseEventHandler,
  modalId: string,
  close: any,
  invalidCredentials?: boolean
}

const Modal = ({
                 title,
                 inputs,
                 handleSubmit,
                 submitBtnTitle,
                 switchQuestion,
                 handleSwitch,
                 modalId,
                 close,
                 invalidCredentials
}
                 : IModalProps) => {

  return (
    <>
      <div id={modalId} className={styles.mainWrapper}>
        <div className={styles.secondaryWrapper}>

          <div onClick={close} className={"flex justify-end cursor-pointer text-2xl"}>
            <AiFillCloseCircle />
          </div>

          <div className={styles.cardTitle}>
            {title}
          </div>

          <div className="mt-2">
            <form onSubmit={handleSubmit}>
              {inputs.map((inp, index) =>
                <div key={inp.id+index}>
                  <div className={styles.inputWrapper}>
                    <div className="relative">
                      <div className={styles.inputIcon}>
                        {inp.icon}
                      </div>
                      <input
                        onChange={(e)=> inp.setValue ? inp.setValue(e.target.value) : null}
                        autoComplete="off"
                        autoCorrect="off"
                        autoCapitalize="off"
                        spellCheck="false"
                        id={inp.id}
                        type={inp.type}
                        className={cn([
                          styles.input,
                          inp.warning ? inp.warning.includes("good") ? "focus:border-green-600" : "focus:border-red-600" : ''
                        ])}
                        placeholder={inp.label}
                        required={modalId === 'signIn'}
                      />
                    </div>
                    {inp.warning &&
                      <div className={cn(["p-1 inline-flex", inp.warning.includes("good") ? "text-green-600" : "text-red-600"])}>
                        {inp.warning}
                      </div>
                    }
                  </div>
                </div>
              )}
              {invalidCredentials !== undefined && <div className={styles.invalidCredentials}>{invalidCredentials ? "Invalid Credentials!" : null}</div>}
              <button type="submit" className={styles.submitButton}>
                <IoMdLogIn className="text-2xl"/>
                <span className="mr-2 pl-2 uppercase">{submitBtnTitle}</span>
              </button>
            </form>
          </div>

          <div className="flex justify-center items-center mt-6">
            <div className={styles.footerWrapper}>
              <GiBottomRight3DArrow className={"text-2xl"}/>
              <span onClick={handleSwitch} className="ml-2">{switchQuestion}</span>
            </div>
          </div>

        </div>
      </div>
    </>
  );
};

export default Modal;
