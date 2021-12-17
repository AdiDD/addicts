import { useState, useEffect } from "react";
import { Navigation } from "./components/Home/navigation";
import { Header } from "./components/Home/header";
// import { Features } from "./components/features";
import { About } from "./components/Home/about";
import { Services } from "./components/Home/services";
import { Gallery } from "./components/Home/gallery";
import { Testimonials } from "./components/Home/testimonials";
import { Team } from "./components/Home/Team";
import { Contact } from "./components/Home/contact";
import JsonData from "./data/data.json";
import SmoothScroll from "smooth-scroll";
import "./App.css";
import axios from "axios";

export const scroll = new SmoothScroll('a[href*="#"]', {
  speed: 1000,
  speedAsDuration: true,
});

const InitialState =  {
  "Header": "",
  "About": "",
  "Services": "",
  "Gallery": "",
  "Team": "",
  "Testimonials": "",
  "Contact": "",
}

const App = () => {
  const [landingPageData, setLandingPageData] = useState(InitialState);
  useEffect(() => {
    axios.get("https://localhost:44350/api/account/check-email/ceva")
    // axios.get("/api/account/check-email/ceva")
      .then((res) => console.log(res.data))
      .catch((err) => console.log(err.response))
    // @ts-ignore
    setLandingPageData(JsonData);
  }, []);

  return (
    <div>
      <Navigation />
      <Header data={landingPageData.Header} />
      {/*<Features data={landingPageData.Features} />*/}
      <About data={landingPageData.About} />
      <Services data={landingPageData.Services} />
      <Gallery data={landingPageData.Gallery}/>
      <Testimonials data={landingPageData.Testimonials} />
      <Team data={landingPageData.Team} />
      <Contact data={landingPageData.Contact} />
    </div>
  );
};

export default App;
