//Layout
import UnlogLayout from "../Layouts/UnlogLayout";

//Pages
import CartPage from "../../pages/CartPage/CartPage";
import ConfirmEmail from "../../pages/ConfirmEmail/ConfirmEmail";
import ForgotPassword from "../../pages/ForgotPassword/ForgotPassword";
import MainPage from "../../pages/MainPage/MainPage";
import ProductPage from "../../pages/ProductPage/ProductPage";
import ResetPassword from "../../pages/ResetPassword/ResetPassword";
import SignIn from "../../pages/SignIn/SignIn";
import SignUp from "../../pages/SignUp/SignUp";
import UserPage from "../../pages/UserPage/UserPage";
import DefaultLayout from "../Layouts/DefaultLayout";

const isLogin = false;

function DefineLayout() {
  return isLogin === true ? DefaultLayout : UnlogLayout;
}

//PublicRoutes
const publicRoutes = [
  { path: "/", component: MainPage, layout: DefineLayout() },
  { path: "/sign_in", component: SignIn, layout: DefineLayout() },
  { path: "/sign_up", component: SignUp },
  { path: "/product_page", component: ProductPage,  },
  { path: "/forgot_password", component: ForgotPassword, layout: null },
  { path: "/cart", component: CartPage },
  { path: "/sign_up", component: SignUp, layout: null },
];
//PrivateRoutes
const privateRoutes = [
  { path: "/confirm_email", component: ConfirmEmail, layout: null },
  { path: "/reset_password", component: ResetPassword, layout: null },
  { path: "/user_page", component: UserPage, layout: UnlogLayout },
];

export { publicRoutes, privateRoutes };
