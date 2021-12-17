import { gsap } from "gsap";

const reset = (resetWarning: () => void) => {
  gsap.set("input", {value: ""});
  resetWarning();
}

export const openModal = (target: string) => {
  gsap.timeline()
    // .set("body", {overflow: "hidden"})
    .fromTo(["#modal-left", "#modal-right"], {width: 0}, {width: "50%"})
    .fromTo(target,
      {opacity: 0, scale: 0, display: "none"},
      {ease: "back.out", opacity: 1, scale: 1, display: "flex"})
  // gsap.fromTo(target,
  //     {opacity: 0, scale: 0, display: "none"},
  //     {ease: "back.out", opacity: 1, scale: 1, display: "flex"}
  // );
}

export const closeModal = (target: string, resetWarning: () => void) =>{
  gsap.timeline()
    .fromTo(target,
      {opacity: 1, scale: 1, display: "flex"},
      {ease: "back.in", opacity: 0, scale: 0, display: "none"}
    )
    .fromTo(["#modal-left", "#modal-right"], {width: "50%"}, {width: 0})
    // .set("body", {overflow: "auto"})
    .set(target, {scale: 1, onComplete: ()=> {
      reset(resetWarning);
    }});
}

export const switchModal = (active: string, inactive: string, resetWarning: () => void) => {
  gsap.timeline()
    .fromTo(active,
      {opacity: 1},
      {duration: 0.5, opacity: 0, ease: "expo.out", display: "none"}
    )
    .fromTo(inactive,
      {opacity: 0},
      {
        duration: 1,
        opacity: 1,
        ease: "expo.in",
        display: "flex",
        onComplete: ()=> {
          reset(resetWarning)
        }},
      "-=0.8"
    )
}
