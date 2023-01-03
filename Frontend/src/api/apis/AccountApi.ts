/* tslint:disable */
/* eslint-disable */
/**
 * API Artisashop
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


import * as runtime from '../runtime';
import type {
  Account,
  AccountToken,
  ExternalLoginConfirmationViewModel,
  GetAccountResult,
  Login,
  ProblemDetails,
  Register,
  UpdateAccount,
} from '../models';
import {
    AccountFromJSON,
    AccountToJSON,
    AccountTokenFromJSON,
    AccountTokenToJSON,
    ExternalLoginConfirmationViewModelFromJSON,
    ExternalLoginConfirmationViewModelToJSON,
    GetAccountResultFromJSON,
    GetAccountResultToJSON,
    LoginFromJSON,
    LoginToJSON,
    ProblemDetailsFromJSON,
    ProblemDetailsToJSON,
    RegisterFromJSON,
    RegisterToJSON,
    UpdateAccountFromJSON,
    UpdateAccountToJSON,
} from '../models';

export interface ApiAccountByEmailEmailGetRequest {
    email: string;
}

export interface ApiAccountExternalLoginCallbackGetRequest {
    returnUrl?: string;
}

export interface ApiAccountExternalLoginPostRequest {
    provider?: string;
    returnUrl?: string;
}

export interface ApiAccountIdGetRequest {
    id: string;
}

export interface ApiAccountIdRoleRolePostRequest {
    id: string;
    role: string;
    isDeleted?: boolean;
}

export interface ApiAccountLoginPostRequest {
    login?: Login;
}

export interface ApiAccountPatchRequest {
    updateAccount?: UpdateAccount;
}

export interface ApiAccountPostRequest {
    register?: Register;
}

/**
 * 
 */
export class AccountApi extends runtime.BaseAPI {

    /**
     */
    async apiAccountByEmailEmailGetRaw(requestParameters: ApiAccountByEmailEmailGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<GetAccountResult>> {
        if (requestParameters.email === null || requestParameters.email === undefined) {
            throw new runtime.RequiredError('email','Required parameter requestParameters.email was null or undefined when calling apiAccountByEmailEmailGet.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/account/byEmail/{email}`.replace(`{${"email"}}`, encodeURIComponent(String(requestParameters.email))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => GetAccountResultFromJSON(jsonValue));
    }

    /**
     */
    async apiAccountByEmailEmailGet(requestParameters: ApiAccountByEmailEmailGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<GetAccountResult> {
        const response = await this.apiAccountByEmailEmailGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAccountDeleteRaw(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<string>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/account`,
            method: 'DELETE',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.TextApiResponse(response) as any;
    }

    /**
     */
    async apiAccountDelete(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<string> {
        const response = await this.apiAccountDeleteRaw(initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAccountExternalLoginCallbackGetRaw(requestParameters: ApiAccountExternalLoginCallbackGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<ExternalLoginConfirmationViewModel>> {
        const queryParameters: any = {};

        if (requestParameters.returnUrl !== undefined) {
            queryParameters['returnUrl'] = requestParameters.returnUrl;
        }

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/account/external-login-callback`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ExternalLoginConfirmationViewModelFromJSON(jsonValue));
    }

    /**
     */
    async apiAccountExternalLoginCallbackGet(requestParameters: ApiAccountExternalLoginCallbackGetRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<ExternalLoginConfirmationViewModel> {
        const response = await this.apiAccountExternalLoginCallbackGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAccountExternalLoginPostRaw(requestParameters: ApiAccountExternalLoginPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<void>> {
        const queryParameters: any = {};

        if (requestParameters.provider !== undefined) {
            queryParameters['provider'] = requestParameters.provider;
        }

        if (requestParameters.returnUrl !== undefined) {
            queryParameters['returnUrl'] = requestParameters.returnUrl;
        }

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/account/external-login`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.VoidApiResponse(response);
    }

    /**
     */
    async apiAccountExternalLoginPost(requestParameters: ApiAccountExternalLoginPostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<void> {
        await this.apiAccountExternalLoginPostRaw(requestParameters, initOverrides);
    }

    /**
     */
    async apiAccountGetRaw(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Account>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/account`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => AccountFromJSON(jsonValue));
    }

    /**
     */
    async apiAccountGet(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Account> {
        const response = await this.apiAccountGetRaw(initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAccountIdGetRaw(requestParameters: ApiAccountIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<GetAccountResult>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiAccountIdGet.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/account/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => GetAccountResultFromJSON(jsonValue));
    }

    /**
     */
    async apiAccountIdGet(requestParameters: ApiAccountIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<GetAccountResult> {
        const response = await this.apiAccountIdGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAccountIdRoleRolePostRaw(requestParameters: ApiAccountIdRoleRolePostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<GetAccountResult>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiAccountIdRoleRolePost.');
        }

        if (requestParameters.role === null || requestParameters.role === undefined) {
            throw new runtime.RequiredError('role','Required parameter requestParameters.role was null or undefined when calling apiAccountIdRoleRolePost.');
        }

        const queryParameters: any = {};

        if (requestParameters.isDeleted !== undefined) {
            queryParameters['isDeleted'] = requestParameters.isDeleted;
        }

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/account/{id}/role/{role}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))).replace(`{${"role"}}`, encodeURIComponent(String(requestParameters.role))),
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => GetAccountResultFromJSON(jsonValue));
    }

    /**
     */
    async apiAccountIdRoleRolePost(requestParameters: ApiAccountIdRoleRolePostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<GetAccountResult> {
        const response = await this.apiAccountIdRoleRolePostRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAccountLoginPostRaw(requestParameters: ApiAccountLoginPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<AccountToken>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/account/login`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: LoginToJSON(requestParameters.login),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => AccountTokenFromJSON(jsonValue));
    }

    /**
     */
    async apiAccountLoginPost(requestParameters: ApiAccountLoginPostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<AccountToken> {
        const response = await this.apiAccountLoginPostRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAccountPatchRaw(requestParameters: ApiAccountPatchRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Account>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/account`,
            method: 'PATCH',
            headers: headerParameters,
            query: queryParameters,
            body: UpdateAccountToJSON(requestParameters.updateAccount),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => AccountFromJSON(jsonValue));
    }

    /**
     */
    async apiAccountPatch(requestParameters: ApiAccountPatchRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Account> {
        const response = await this.apiAccountPatchRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAccountPostRaw(requestParameters: ApiAccountPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<AccountToken>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/account`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: RegisterToJSON(requestParameters.register),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => AccountTokenFromJSON(jsonValue));
    }

    /**
     */
    async apiAccountPost(requestParameters: ApiAccountPostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<AccountToken> {
        const response = await this.apiAccountPostRaw(requestParameters, initOverrides);
        return await response.value();
    }

}
