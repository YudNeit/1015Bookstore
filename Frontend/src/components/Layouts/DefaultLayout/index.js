import Header from "./Header/Header";
import Footer from "../DefaultLayout/Footer/Footer";

function DefaultLayout({ children }) {
  return (
    <div>
      <Header />
      <div
        className="content"
        style={{
          backgroundColor: "#f5f5f5",
          padding: "1vh 0px",
        }}
      >
        {children}
      </div>
      <Footer />
    </div>
  );
}

export default DefaultLayout;
