import styles from "./Toast.module.css";
import cn from "classnames";

interface IToast {
  toastId: string,
  iconColor: string,
  icon: JSX.Element,
  titleColor: string,
  title: string,
  message?: string
}

const Toast = ({toastId, iconColor, icon, titleColor, title, message}: IToast) => {
  return (
    <>
      <div id={toastId} className={styles.mainWrapper}>
        <div className={cn([styles.mainIconWrapper, iconColor])}>
          <span className={styles.iconWrapper}>
            {icon}
          </span>
        </div>

        <div className={styles.messageWrapper}>
          <div className="mx-3">
            <span className={cn(["font-semibold", titleColor])}>
              <p>{title}</p>
            </span>
            {message && <p className={styles.message}>{message}</p>}
          </div>
        </div>
      </div>
    </>
  );
};

export default Toast;