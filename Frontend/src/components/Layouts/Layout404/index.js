import React from "react";
import img404 from "../../../assets/images/img404.png";

function Layout404({ children }) {
  return (
    <div>
      <div
      
        className="content"
        style={{
          backgroundImage: `url(${img404})`,
          backgroundRepeat: "no-repeat",
          height: "80vh",
          width: "100vw",
        }}
      >
        {children}
      </div>
    </div>
  );
}

export default Layout404;
