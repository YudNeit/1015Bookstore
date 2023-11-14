import CartPage  from "../../pages/CartPage/CartPage"
import ConfirmEmail from "../../pages/ConfirmEmail/ConfirmEmail"
import ForgotPassword from "../../pages/ForgotPassword/ForgotPassword"
import MainPage from "../../pages/MainPage/MainPage"
import ProductPage from "../../pages/ProductPage/ProductPage"
import ResetPassword from "../../pages/ResetPassword/ResetPassword"
import SignIn from "../../pages/SignIn/SignIn"
import SignUp from "../../pages/SignUp/SignUp"
import UserPage from "../../pages/UserPage/UserPage"
import { BrowserRouter, Routes, Route } from "react-router-dom";



function AppRoutes() {
  return (
    <BrowserRouter>
       <Routes>
        <Route path="/Main" element={<MainPage />}/>
        <Route path="/CartPage" element={<CartPage />}/>
        <Route path="/ConfirmEmail" element={<ConfirmEmail />}/>
        <Route path="/ForgotPassword" element={<ForgotPassword />}/>
        <Route path="/ProductPage" element={<ProductPage />}/>
        <Route path="/ResetPassword" element={<ResetPassword/>}/>
        <Route path="/SignIn" element={<SignIn />}/>
        <Route path="/SignUp" element={<SignUp />}/>
        <Route path="/UserPage" element={<UserPage />}/>
      </Routes>
      </BrowserRouter>
  )
}

export default AppRoutes
