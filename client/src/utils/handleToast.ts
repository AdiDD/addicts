import { gsap } from "gsap";

export const showToast = (toastId: string, username?: string): void => {
  if (username) {
    const message = document.querySelector(`${toastId} p`)!;
    message.innerHTML = "";
    message.innerHTML = `Welcome ${username}!`;
  }

  gsap.timeline()
    .fromTo(toastId,
      {opacity: 0, scale: 0, display: "none"},
      {ease: "back.out", opacity: 1, scale: 1, display: "flex"})
    .fromTo(toastId,
      {opacity: 1, scale: 1, display: "flex"},
      {ease: "back.in", opacity: 0, scale: 0, display: "none"}, "+=5")
}