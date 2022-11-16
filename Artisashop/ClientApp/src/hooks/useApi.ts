import { useMemo } from "react";
import {Configuration} from "../api";
import { REACT_APP_API_URL } from "../conf";
import { useAuth } from "./useAuth";

/**
 * Returns a configured instance of the API.
 * @param Api the type of the API to return
 * @example `const api = useApi(AccountApi)`
 */
const useApi = <T,>(Api: { new(config: Configuration) : T;}) : T => {
  const auth = useAuth()
  const config = useMemo(() => 
    auth?.token
      ? new Configuration({ basePath: REACT_APP_API_URL, accessToken: auth.token })
      : new Configuration({ basePath: REACT_APP_API_URL })
  , [auth, auth?.token])
  return useMemo(() => new Api(config), [Api, config]);
}

export default useApi;
