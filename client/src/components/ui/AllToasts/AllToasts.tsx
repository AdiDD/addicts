import Toast from "../Toast";
import {AiOutlineSmile} from "react-icons/ai";
import {RiEmotionSadFill} from "react-icons/ri";
import {BsFillHandThumbsUpFill} from "react-icons/bs";

const AllToasts = () => (
  <>
    <Toast
      toastId={"created"}
      iconColor={"bg-green-500"}
      icon={<BsFillHandThumbsUpFill/>}
      titleColor={"text-green-500"}
      title={"Success"}
      message={"Your account was registered!"}
    />
    <Toast
      toastId={"welcome"}
      iconColor={"bg-blue-500"}
      icon={<AiOutlineSmile/>}
      titleColor={"text-blue-500"}
      title={"Welcome"}
    />
    <Toast
      toastId={"error"}
      iconColor={"bg-red-500"}
      icon={<RiEmotionSadFill/>}
      titleColor={"text-red-500"}
      title={"Error"}
      message={"There was a problem please try again!"}
    />
  </>
);

export default AllToasts;