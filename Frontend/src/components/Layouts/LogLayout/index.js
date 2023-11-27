import background_log from "../../../assets/images/background_log.png";
import Footer from "../DefaultLayout/Footer/Footer";

function LogLayout({ children }) {
  return (
    <div>
      <div
        className="content"
        style={{
          backgroundImage: `url(${background_log})`,
          backgroundRepeat: "no-repeat",
          height: "80vh",
          width: "100vw",
        }}
      >
        {children}
      </div>
      <Footer
        style={{
          height: "20vh",
        }}
      />
    </div>
  );
}

export default LogLayout;
