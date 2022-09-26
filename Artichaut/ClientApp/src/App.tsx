import {Navigate, Outlet, Route, Routes} from 'react-router-dom'

import LayoutAdmin from './layouts/admin'
import LayoutAuth from './layouts/auth'
import LayoutDashboard from './layouts/dashboard'
import Chat from './pages/chat'
import Login from "./pages/auth/login";
import Register from "./pages/auth/register";
import PrivacyPolicyPage from "./pages/about/privacy-policy.mdx";
import MDXComponents from "./utility/MDXComponents";
import {useAuth} from "./hooks/useAuth";
import ProfilePage from "./pages/profile/profile";

function App() {
    const auth = useAuth();

    return (
        <Routes>
            <Route path="admin" element={<LayoutAdmin/>}>
            </Route>
            <Route path="auth" element={<LayoutAuth/>}>
                <Route path="login" element={<Login/>}/>
                <Route path="register" element={<Register/>}/>
            </Route>

            <Route path="/" element={<LayoutDashboard/>}>
                <Route path="a-propos">
                    <Route path="politique-confidentialite" element={<PrivacyPolicyPage components={MDXComponents}/>}/>
                </Route>
                <Route path="chat/:userId" element={<Chat/>}/>
                <Route path="profile" element={auth?.user ? <Outlet/> : <Navigate to={'/auth/login'}/>}>
                    <Route index element={<ProfilePage/>}/>
                </Route>
            </Route>
        </Routes>
    )
}

export default App
