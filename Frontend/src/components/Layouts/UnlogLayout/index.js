import Header from "./Header/Header";
import Footer from "./Footer/Footer";

function UnlogLayout({ children }) {
  return (
    <div>
      <Header />
      <div className="content">{children}</div>
    </div>
  );
}

export default UnlogLayout;
