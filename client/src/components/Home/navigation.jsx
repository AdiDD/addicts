// import {Link} from "react-router-dom";

import {openModal} from "../../utils/handleModal";
// import SignIn from "../../auth/SignIn";
// import SignUp from "../../auth/SignUp";

export const Navigation = (props) => {
  return (
    <nav id='menu' className='navbar navbar-default navbar-fixed-top'>
      <div className='container'>
        <div className='navbar-header'>
          <button
            type='button'
            className='navbar-toggle collapsed'
            data-toggle='collapse'
            data-target='#bs-example-navbar-collapse-1'
          >
            {' '}
            <span className='sr-only'>Toggle navigation</span>{' '}
            <span className='icon-bar'/>{' '}
            <span className='icon-bar'/>{' '}
            <span className='icon-bar'/>{' '}
          </button>
          <a className='navbar-brand page-scroll' href='#page-top'>
            Wellness Zone
          </a>{' '}
        </div>

        <div
          className='collapse navbar-collapse'
          id='bs-example-navbar-collapse-1'
        >
          <ul className='nav navbar-nav navbar-right'>
            <li>
              <a href='#about' className='page-scroll'>
                Home
              </a>
            </li>
            <li>
              <a href='#' className='page-scroll'>
                Community
              </a>
            </li>
            <li>
              <a href='#services' className='page-scroll'>
                Healing
              </a>
            </li>
            <li>
              <a href='#portfolio' className='page-scroll'>
                Gallery
              </a>
            </li>
            <li>
              <a href='#testimonials' className='page-scroll'>
                Testimonials
              </a>
            </li>
            <li>
              <a href='#team' className='page-scroll'>
                COUNSELLORS
              </a>
            </li>
            <li>
              <p className='page-scroll' onClick={() => openModal("#signIn")}>
                Login
              </p>
            </li>
          </ul>
        </div>
      </div>
      <div id={"modal-left"} className={"bg-black/80 h-screen fixed left-0 z-50"} />
      <div id={"modal-right"} className={"bg-black/80 h-screen fixed right-0 z-50"} />
      {/*<SignIn />*/}
      {/*<SignUp />*/}
    </nav>
  )
}
