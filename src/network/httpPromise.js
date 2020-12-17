import axios from 'axios'

// export function request(config) {
//     const instance = axios.create({
//         baseURL: "https://localhost:44305",
//         // timeout: 5000,
//     })
//     return instance(config)
// }

export function request(config) {
    return new Promise((resolve, reject) => {
        const instance = axios.create({
            baseURL: "https://localhost:44361/",
            //timeout:5000,
        })
        instance(config)
            .then(res =>  resolve(res))
            .catch(err =>   reject(err))
    })

}


