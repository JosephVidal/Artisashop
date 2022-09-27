import {ChakraProvider} from '@chakra-ui/react'
import React from 'react'
import ReactDOM from 'react-dom/client'
import {BrowserRouter} from 'react-router-dom'
import App from './App'
import './index.css'
import {ProvideAuth} from "./hooks/useAuth";

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
    <React.StrictMode>
        <BrowserRouter>
            <ProvideAuth>
                <ChakraProvider>
                    <App/>
                </ChakraProvider>
            </ProvideAuth>
        </BrowserRouter>
    </React.StrictMode>
)
