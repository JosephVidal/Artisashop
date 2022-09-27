// Hook (use-auth.js)
import React, {useContext, createContext} from "react";
import {AccountApi, Configuration, Register, AccountToken, UserType, Account} from "../api";
import useApiUrl from "./useApiUrl";
import useLocalStorage from "./useLocalstorage";

export interface IProvideAuth {
    signin: (username: string, password: string) => Promise<AccountToken>
    signout: () => void
    confirmPasswordReset: (code: string, password: string) => void
    user?: Account | null
    signup: (model: Register) => Promise<AccountToken>
    sendPasswordResetEmail: (email: string) => void
    token?: string | null
}

const AuthContext = createContext<IProvideAuth | null>(null);

// Provider component that wraps your app and makes auth object ...
// ... available to any child component that calls useAuth().
export const ProvideAuth: React.FC<{ children: JSX.Element }> = ({children}) => {
    const auth = useProvideAuth();
    return <AuthContext.Provider value={auth}>{children}</AuthContext.Provider>;
}

// Hook for child components to get the auth object ...
// ... and re-render when it changes.
export const useAuth = () => {
    return useContext(AuthContext);
};

// Provider hook that creates auth object and handles state
function useProvideAuth() : IProvideAuth {
    const [user, setUser] = useLocalStorage<Account>("user", null);
    const [token, setToken] = useLocalStorage("token", "")
    const apiUrl = useApiUrl();
    const api = new AccountApi(new Configuration({
        basePath: apiUrl,
    }));
    const tmp = useLocalStorage<Account>("user", null);

    // Wrap any Firebase methods we want to use making sure ...
    // ... to save the user to state.
    const signin = (email: string, password: string) => {
        return api.apiAccountLoginPost({
            login: { email, password },
        }).then(res => {
            setUser(res.user ?? null)
            setToken(res.token ?? null)
            return res
        })
    };

    const signup = (register: Register) => {
        return api.apiAccountRegisterPost({
            register
        }).then(res => {
            setUser(res.user ?? null)
            setToken(res.token ?? null)
            return res
        })
    };

    const signout = () => {
        setUser(null)
        setToken(null)
    };

    const sendPasswordResetEmail = (email: string) => {
        // TODO: implement
    };

    const confirmPasswordReset = (code: string, password: string) => {
        // TODO: implement
    };

    // Return the user object and auth methods
    return {
        user,
        token,
        signin,
        signup,
        signout,
        sendPasswordResetEmail,
        confirmPasswordReset,
    };
}