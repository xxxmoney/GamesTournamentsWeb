import axios from 'axios'

const useApi = () => {
  const config = useRuntimeConfig()
  const baseURL = config.public.API_URL as string

  const mainStore = useMainStore()

  return axios.create({
    baseURL,
    headers: {
      Authorization: `Bearer ${mainStore.loginResult?.token ?? ''}`
    }
  })
}

export { useApi }
