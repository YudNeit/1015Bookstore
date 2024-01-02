//Layout
import UnlogLayout from "../Layouts/UnlogLayout";
import LogLayout from "../Layouts/LogLayout";
import DefaultLayout from "../Layouts/DefaultLayout";
import Layout404 from "../Layouts/Layout404";

//Pages
import CartPage from "../../pages/CartPage/CartPage";
import ConfirmCode from "../../pages/ConfirmCode";
import ForgotPasswordPage from "../../pages/ForgotPassword/ForgotPassword";
import MainPage from "../../pages/MainPage/MainPage";
import ProductPage from "../../pages/ProductPage/ProductPage";
import SignIn from "../../pages/SignIn/SignIn";
import SignUp from "../../pages/SignUp/SignUp";
import ChangePasswordPage from "../../pages/ChangePasswordPage";
import ProfilePage from "../../pages/ProflePage";
import Page404 from "../../pages/404Page";
import CheckoutPage from "../../pages/CheckoutPage";
import FilteredPage from "../../pages/Category";




function DefineLayout() {
  const isUserAuthenticated = () => {
    // Replace this with your actual authentication logic
    const accessToken = getCookie('accessToken');
    const userid = getCookie('userid');
    return accessToken && userid;
  };

  const getCookie = (cookieName) => {
    const cookies = document.cookie.split('; ');
    for (const cookie of cookies) {
      const [name, value] = cookie.split('=');
      if (name === cookieName) {
        return value;
      }
    }
    return null;
  };
  return isUserAuthenticated() ? DefaultLayout : UnlogLayout;
}

//PublicRoutes
const publicRoutes = [
  { path: "/", component: MainPage, layout: DefineLayout() },
  { path: "/:selectedMenu", component: FilteredPage, layout: DefineLayout() },
  { path: "/sign_in", component: SignIn, layout: LogLayout },
  { path: "/sign_up", component: SignUp, layout: LogLayout },
  { path: "/product-detail/:id", component: ProductPage, layout: DefineLayout() },
  {
    path: "/forgot_password",
    component: ForgotPasswordPage,
    layout: LogLayout,
  },
  {
    path: "/change_password",
    component: ChangePasswordPage,
    layout: LogLayout,
  },
  { path: "/404_page", component: Page404, layout: Layout404 },
  { path: "/confirm_code", component: ConfirmCode, layout: LogLayout },
  { path: "/profile_page", component: ProfilePage, layout: DefineLayout() },
  { path: "/checkout", component: CheckoutPage, layout: DefineLayout() },
  { path: "/cart", component: CartPage },
];
//PrivateRoutes
const privateRoutes = [



];

export { publicRoutes, privateRoutes };
