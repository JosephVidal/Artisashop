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


/**
 * 
 * @export
 */
export const State = {
    Waitingcraftsman: 'WAITINGCRAFTSMAN',
    Waitingconsumer: 'WAITINGCONSUMER',
    Refused: 'REFUSED',
    Validated: 'VALIDATED',
    Ongoing: 'ONGOING',
    Delivery: 'DELIVERY',
    End: 'END'
} as const;
export type State = typeof State[keyof typeof State];


export function StateFromJSON(json: any): State {
    return StateFromJSONTyped(json, false);
}

export function StateFromJSONTyped(json: any, ignoreDiscriminator: boolean): State {
    return json as State;
}

export function StateToJSON(value?: State | null): any {
    return value as any;
}

