import axios from 'axios'

export const useApi = () => {
  const baseURL = process.env.API
  const mainStore = useMainStore()

  return axios.create({
    baseURL,
    headers: {
      Authorization: `Bearer ${mainStore.loginResult?.token ?? ''}`
    }
  })
}
